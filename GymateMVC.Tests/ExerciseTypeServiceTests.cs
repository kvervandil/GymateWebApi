using GymateMVC.Application.Services;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using GymateMVC.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GymateMVC.Tests
{
    public class ExerciseTypeServiceTests
    {
        [Fact]
        public void Should_RepoGetAllExerciseTypes_ReturnCorrectVm_WhenGetAllExerciseTypesCalled()
        {
            List<Exercise> exercises = new List<Exercise>()
            {
                new Exercise() {Id = 1, Name = "dummyExercise1", ExerciseTypeId = 1},
                new Exercise() {Id = 2, Name = "dummyExercise2", ExerciseTypeId = 1}
            };

            List<ExerciseType> exerciseTypes = new List<ExerciseType>()
            {
                new ExerciseType()
                {
                    Id = 1,
                    Name = "dummy 1",
                    Exercises = exercises
                },
                new ExerciseType()
                {
                    Id = 2,
                    Name = "dummy 2",
                    Exercises = exercises
                },
                new ExerciseType()
                {
                    Id = 3,
                    Name = "dummy 3",
                    Exercises = exercises
                }
            };

            var exerciseTypesQuery = exerciseTypes.AsQueryable();

            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            exerciseTypeRepo.Setup(r => r.GetAllExerciseTypes()).Returns(exerciseTypesQuery);

            var expectedResult = new ListForExerciseTypeListVm()
            {
                ListForExerciseTypeList = new List<ExerciseTypeForListVm>()
                {
                    new ExerciseTypeForListVm()
                    {
                        Id = 1,
                        Name = "dummy 1",
                    },
                    new ExerciseTypeForListVm()
                    {
                        Id = 2,
                        Name = "dummy 2",
                    },
                    new ExerciseTypeForListVm()
                    {
                        Id = 3,
                        Name = "dummy 3",
                    },
                },
                PageSize = 3,
                CurrentPage = 1,
                SearchString = string.Empty,
                Count = 3                
            };

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            var result = objectUnderTest.GetAllExerciseTypes(3, 1, string.Empty);

            bool areListsEqual = AreListsForExerciseTypesEqual(result, expectedResult);

            Assert.True(areListsEqual);
        }


        [Fact]
        public void Should_RepoGetAllExerciseTypes_ReturnOnlyFirstVm_WhenGetAllExerciseTypesCalledWithPageSizeOne()
        {
            List<Exercise> exercises = new List<Exercise>()
            {
                new Exercise() {Id = 1, Name = "dummyExercise1", ExerciseTypeId = 1},
                new Exercise() {Id = 2, Name = "dummyExercise2", ExerciseTypeId = 1}
            };

            List<ExerciseType> exerciseTypes = new List<ExerciseType>()
            {
                new ExerciseType()
                {
                    Id = 1,
                    Name = "dummy 1",
                    Exercises = exercises
                },
                new ExerciseType()
                {
                    Id = 2,
                    Name = "dummy 2",
                    Exercises = exercises
                },
                new ExerciseType()
                {
                    Id = 3,
                    Name = "dummy 3",
                    Exercises = exercises
                }
            };

            var exerciseTypesQuery = exerciseTypes.AsQueryable();

            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            exerciseTypeRepo.Setup(r => r.GetAllExerciseTypes()).Returns(exerciseTypesQuery);

            var expectedResult = new ListForExerciseTypeListVm()
            {
                ListForExerciseTypeList = new List<ExerciseTypeForListVm>()
                {
                    new ExerciseTypeForListVm()
                    {
                        Id = 1,
                        Name = "dummy 1",
                    },
                },
                PageSize = 1,
                CurrentPage = 1,
                SearchString = string.Empty,
                Count = 3
            };

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            var result = objectUnderTest.GetAllExerciseTypes(1, 1, string.Empty);

            bool areListsEqual = AreListsForExerciseTypesEqual(result, expectedResult);

            Assert.True(areListsEqual);
        }
        
        [Fact]
        public void Should_RepoGetAllExerciseTypes_ReturnEmptyList_WhenGetAllExerciseTypesCalledOnEmptyRepo()
        {
            List<ExerciseType> exerciseTypes = new List<ExerciseType>();

            var exerciseTypesQuery = exerciseTypes.AsQueryable();

            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            exerciseTypeRepo.Setup(r => r.GetAllExerciseTypes()).Returns(exerciseTypesQuery);

            var expectedResult = new ListForExerciseTypeListVm()
            {
                ListForExerciseTypeList = new List<ExerciseTypeForListVm>(),
                PageSize = 1,
                CurrentPage = 1,
                SearchString = string.Empty,
                Count = 0
            };

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            var result = objectUnderTest.GetAllExerciseTypes(1, 1, string.Empty);

            bool areListsEqual = AreListsForExerciseTypesEqual(result, expectedResult);

            Assert.True(areListsEqual);
        }


        private bool AreListsForExerciseTypesEqual(ListForExerciseTypeListVm result, ListForExerciseTypeListVm expectedResult)
        {
            return AreListsEqual(result.ListForExerciseTypeList, expectedResult.ListForExerciseTypeList)
                && result.SearchString == expectedResult.SearchString
                && result.Count == expectedResult.Count
                && result.CurrentPage == expectedResult.CurrentPage
                && result.PageSize == expectedResult.PageSize;
        }

        private bool AreListsEqual(List<ExerciseTypeForListVm> listForExerciseTypeList1, List<ExerciseTypeForListVm> listForExerciseTypeList2)
        {
            bool AreEqual = listForExerciseTypeList1.Count == listForExerciseTypeList2.Count;

            for (int i = 0; i < listForExerciseTypeList1.Count; i++)
            {
                if (listForExerciseTypeList1[i].Id != listForExerciseTypeList2[i].Id
                    || listForExerciseTypeList1[i].Name != listForExerciseTypeList2[i].Name)
                {
                    AreEqual = false;
                }
            }

            return AreEqual;
        }

        [Fact]
        public void Should_RepoGetAllExerciseTypes_BeCalled_WhenGetAllExerciseTypesCalled()
        {
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            exerciseTypeRepo.Setup(r => r.GetAllExerciseTypes()).Returns(new List<ExerciseType>().AsQueryable());

            objectUnderTest.GetAllExerciseTypes(1, 1, string.Empty);

            exerciseTypeRepo.Verify(r => r.GetAllExerciseTypes(), Times.Once);
        }

        [Fact]
        public void Should_RepoAddItemBeCalled_When_ServiceAddItemCalled()
        {
            var exerciseTypeVm = new NewExerciseTypeVm()
            {
                Id = 1,
                Name = "dummy"
            };

            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            exerciseTypeRepo.Setup(r => r.AddExerciseType(It.IsAny<ExerciseType>())).Returns(1);

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            var result = objectUnderTest.AddExerciseType(exerciseTypeVm);

            exerciseTypeRepo.Verify(r => r.AddExerciseType(It.IsAny<ExerciseType>()), Times.Once);

            Assert.Equal(exerciseTypeVm.Id, result);
        }

        [Fact]
        public void Should_RepoUpdateExerciseTypeBeCalled_When_ServiceUpdateExerciseTypCalled()
        {
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            var exerciseTypeVm = new NewExerciseTypeVm()
            {
                Id = 1,
                Name = "dummy"
            };

            objectUnderTest.UpdateExerciseType(exerciseTypeVm);

            exerciseTypeRepo.Verify(r => r.UpdateExerciseType(It.IsAny<ExerciseType>()),Times.Once);
        }

        [Fact]
        public void Should_GetSelectListOfAllExerciseTypes_Return_CorrectList()
        {
            List<Exercise> exercises = new List<Exercise>()
            {
                new Exercise() {Id = 1, Name = "dummyExercise1", ExerciseTypeId = 1},
                new Exercise() {Id = 2, Name = "dummyExercise2", ExerciseTypeId = 1}
            };

            List<ExerciseType> exerciseTypes = new List<ExerciseType>()
            {
                new ExerciseType()
                {
                    Id = 1,
                    Name = "dummy 1",
                    Exercises = exercises
                },
                new ExerciseType()
                {
                    Id = 2,
                    Name = "dummy 2",
                    Exercises = exercises
                },
                new ExerciseType()
                {
                    Id = 3,
                    Name = "dummy 3",
                    Exercises = exercises
                }
            };

            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            var exerciseTypesQuery = exerciseTypes.AsQueryable();

            exerciseTypeRepo.Setup(r => r.GetAllExerciseTypes()).Returns(exerciseTypesQuery);

            var expectedResult = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "1",
                    Text = "dummy 1",
                    Selected = true
                },
                new SelectListItem()
                {
                    Value = "2",
                    Text = "dummy 2"                    
                },
                new SelectListItem()
                {
                    Value = "3",
                    Text = "dummy 3"
                }
            };

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            var result = objectUnderTest.GetSelectListOfAllExerciseTypes(1);

            exerciseTypeRepo.Verify(r => r.GetAllExerciseTypes(), Times.Once);

            Assert.True(AreListsEqual(result, expectedResult));
        }

        private bool AreListsEqual(List<SelectListItem> exerciseTypeSelectList1, List<SelectListItem> exerciseTypeSelectList2)
        {
            bool AreEqual = exerciseTypeSelectList1.Count == exerciseTypeSelectList2.Count;

            for (int i = 0; i < exerciseTypeSelectList1.Count; i++)
            {
                if (exerciseTypeSelectList1[i].Value != exerciseTypeSelectList2[i].Value
                    || exerciseTypeSelectList1[i].Text != exerciseTypeSelectList2[i].Text
                    || exerciseTypeSelectList1[i].Selected != exerciseTypeSelectList2[i].Selected)
                {
                    AreEqual = false;
                }
            }

            return AreEqual;
        }

        [Fact]
        public void Should_RepoDeleteExerciseTypeBeCalled_WhenServiceExerciseTypeCalledWithCorrectId()
        {
            var exerciseType = new ExerciseType()
            {
                Id = 1,
                Name = "dummy"
            };

            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();

            var objectUnderTest = new ExerciseTypeService(exerciseTypeRepo.Object);

            objectUnderTest.DeleteExerciseType(exerciseType.Id);

            exerciseTypeRepo.Verify(r => r.DeleteExerciseType(exerciseType.Id), Times.Once);
        }

    }
}
