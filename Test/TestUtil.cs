using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Catan.Controller.TurnMachines;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace Test
{
    [Binding]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedParameter.Global")]
    public static class TestUtil
    {
        [StepArgumentTransformation(@"( valid )")]
        [StepArgumentTransformation(@"( can )")]
        [StepArgumentTransformation(@"( does )")]
        [StepArgumentTransformation(@"( has )")]
        public static bool TrueWords(string word)
        {
            return true;
        }

        
        [StepArgumentTransformation(@"( lacks )")]
        [StepArgumentTransformation(@"( invalid )")]
        [StepArgumentTransformation(@"( cannot )")]
        [StepArgumentTransformation(@"( doesn't )")]
        public static bool FalseWords(string word)
        {
            return false;
        }

        public class TestState : TurnState
        {
            public TestState(GameModel model) : base(model)
            {
            }

            internal override string Prompt => "";
            public override TurnState HandleInput(PlayerAction action)
            {
                throw new NotImplementedException();
            }
        }

        public static void SetupStateDictionary(GameModel model, MockRepository mocks, ISet<TurnState> real, int fixtureCount = 0)
        {
            // Get mocks.Create[SOME TYPE]. Make sure it takes a generic parameter. Make sure it's the one that takes in MockBehavior & arguments for constructor
            var genericMethod = mocks.GetType().GetMethods().Single(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetParameters().Length == 2);
            
            // Fixture count = number of Test Fixture classes (i.e. not in Catan project), currently 1 when testing DevCard
            var stateDict = new Dictionary<Type, dynamic>();
            foreach (var type in GameModel.TurnStateList)
            {
                if (real.All(s => s.GetType() != type))
                {
                    var method = genericMethod.MakeGenericMethod(type);
                    dynamic mock = (Mock) method.Invoke(mocks, new object[] {MockBehavior.Loose, new object[]{model}});
                    var obj = mock.Object;
                    Mock<ITurnState> turnStateMock = mock.As<ITurnState>();
                    turnStateMock.Setup(t => t.HandleInput(It.IsAny<PlayerAction>())).Returns((TurnState) obj);
                    stateDict.Add(type, obj); 
                }
                
            }

            foreach (var state in real)
            {
                stateDict.Add(state.GetType(), state);
            }

            stateDict.Add(typeof(TestState), new TestState(model));
            Assert.AreEqual(GameModel.TurnStateList.Count+fixtureCount + 1,stateDict.Count);
            model.StateDictionary = stateDict.ToImmutableDictionary();
        }
       
    }
}
