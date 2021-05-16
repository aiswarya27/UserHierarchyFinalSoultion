using System;
using System.Collections.Generic;
using System.Data;
using UsersHierarchy.BL.System;
using UsersHierarchy.Domain;
using UsersHierarchy.UI.DataAccess;
using Xunit;

namespace UserHierarchy.Tests
{
    public class SystemComponentTest
    {
        SystemComponent sm = null;
        [Fact]
        public void shouldParseJsonFromFile()
        {
            SystemComponent sm = JsonParser<SystemComponent>.parseJson();
            Assert.NotNull(sm);
            Assert.IsType<SystemComponent>(sm);
        }

        [Fact]
        public void shouldCreateSystemComponentObject()
        {
            SystemRepository systemRepository = new SystemRepository();
            SystemBuilder systemBuilder = new SystemBuilder(systemRepository);
            SystemComponent sm = systemRepository.Create();
            Assert.NotNull(sm);
            Assert.IsType<SystemComponent>(sm);

        }

        [Fact]
        public void getSuboordinateFunctionTest()
        {
            initializeSystem();
            IList<User> SubOrdinateList = sm.getSuboordinate(1);
            Assert.Equal(1, SubOrdinateList.Count);
            Assert.Equal(2, SubOrdinateList[0].Id);
        }

        [Fact]
        public void getSubRolesFunctionTest()
        {
            initializeSystem();
            IList<Role> SubRoleList = sm.getSubRolesForGivenRole(1);
            Assert.Equal(1, SubRoleList.Count);
            Assert.Equal(2, SubRoleList[0].Id);
        }

        [Fact]
        public void getSubRolesFunctionShouldReturnEmptyIfNoUserFoundTest()
        {
            initializeSystem();
            IList<Role> SubRoleList = sm.getSubRolesForGivenRole(3);
            Assert.Equal(0,SubRoleList.Count);            
        }

        [Fact]
        public void getUserRoleFunctionTest()
        {
            initializeSystem();
            int role=sm.getUserRole(1);
            Assert.Equal(1, role);            
        }

        [Fact]
        public void getUserRoleFunctionTestWhenNoRoleIdentified()
        {
            initializeSystem();
            int role = sm.getUserRole(0);
            Assert.Equal(-1, role);
        }

        [Fact]
        public void getUsersWithGivenRolesFunctionTest()
        {
            initializeSystem();
            IList<User> usersList= sm.getUsersWithGivenRoles(sm.roles);
            Assert.Equal(2, usersList.Count);                     
        }

        [Fact]
        public void getUsersWithGivenRolesFunctionTestWhenNullRolesPassed()
        {
            initializeSystem();
            
            Assert.Null(sm.getUsersWithGivenRoles(null));
        }

        private void initializeSystem()
        {
            IList<User> user = new List<User> {
                                        new User {Id=1, Name = "Adam Admin", Role=1 },
                                            new User {Id=2, Name = "EmilyEmployee Admin", Role=2} };
            IList<Role> roles = new List<Role> {
                                        new Role {Id=1, Name = "System Admin", Parent=0 },
                                            new Role {Id=2, Name = "Location Manaer", Parent=1} };
            sm = new SystemComponent(roles, user);
        }


    }

}

