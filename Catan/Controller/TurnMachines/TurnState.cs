using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Catan.Model;
using JetBrains.Annotations;

namespace Catan.Controller.TurnMachines
{
    // Using ITurnState so Moq works well with mocking TestUtil.cs
    public interface ITurnState
    {
        void OnEnter();
        TurnState HandleInput(PlayerAction action);
    }

    public abstract class TurnState : ITurnState
    {
        protected readonly GameModel Model;

        public Type ReturnStateType;

        protected delegate void OnEnterDelegate();

        protected GameBoard Board => Model.Board;
        protected Bank Bank => Model.Bank;
        protected ImmutableList<Player> Players => Model.Players;
        protected Presenter Presenter => Model.Presenter;

        protected int ActivePlayerIndex
        {
            get => Model.ActivePlayerIndex;
            set => Model.ActivePlayerIndex = value;
        }

        protected Player ActivePlayer => Model.ActivePlayer;

        protected TurnState State(Type t)
        {
            return Model.State(t);
        }

        protected T State<T>() where T : TurnState
        {
            return Model.State<T>();
        }

        internal abstract string Prompt { get; }

        /// <summary>
        /// Gets the ReturnState specified to return to when TurnState leaves. Throws InvalidOperationException if not set.
        /// Note: you must set the ReturnStateType every time you enter a TurnState; this ensures TurnStates do not unexpected state between calls
        /// </summary>
        protected internal TurnState ReturnState
        {
            get
            {
                if (ReturnStateType == null)
                {
                    throw new InvalidOperationException(@"No state to return to!");
                }

                var result = State(ReturnStateType);
                ReturnStateType = null;
                return result;
            }
        }

        protected readonly List<OnEnterDelegate> OnEnterList;

        protected TurnState(GameModel model)
        {
            Model = model;
            OnEnterList = new List<OnEnterDelegate> {DefaultOnEnter};
        }

        public void OnEnter()
        {
            foreach (var onEnter in OnEnterList)
            {
                onEnter();
            }
        }

        protected void DefaultOnEnter()
        {
            PromptUser(Prompt);
            Presenter.DisplayPlayerResources(ActivePlayer);
        }

        protected void PromptUser([LocalizationRequired(true)] string msg)
        {
            PromptError(@"");
            Presenter.PromptUser(ActivePlayer, msg);
        }
        
        protected void PromptError([LocalizationRequired(true)] string msg)
        {
            Presenter.PromptError(msg);
        }

        public abstract TurnState HandleInput(PlayerAction action);
    }
}