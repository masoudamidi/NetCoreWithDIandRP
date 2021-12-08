using System;
using Xunit;
using BusinessLogic.BLL;
using DataAccess.Data;
using Moq;
using RoamlerTest.Controllers;
using Microsoft.EntityFrameworkCore;

namespace RoamlerXUnitTests
{

    public class bllLocationTest
    {

        [Fact]
        public void TestMaxResult()
        {
            using (var _context = new NetCoreWithDIandRPContext(DbOptionsFactory.DbContextOptions))
            {
                var _gl = new LocationsRepository(_context);

                // Act
                var results = _gl.GetLocations(52.2165412902832, 5.47785329818726, 1000, 10);

                var count = results.locations.Count;

                // Assert
                Assert.Equal(10, count);
                Assert.Equal(true, results.Status);
            }
        }

        [Fact]
        public void TestMaxDistanceVariable()
        {
            using (var _context = new NetCoreWithDIandRPContext(DbOptionsFactory.DbContextOptions))
            {
                var _gl = new LocationsRepository(_context);

                // Act
                var results = _gl.GetLocations(52.2165412902832, 5.47785329818726, -1, 10);

                // Assert
                Assert.Equal(false, results.Status);
            }
        }

        [Fact]
        public void TestMaxResultVariable()
        {
            using (var _context = new NetCoreWithDIandRPContext(DbOptionsFactory.DbContextOptions))
            {
                var _gl = new LocationsRepository(_context);

                // Act
                var results = _gl.GetLocations(52.2165412902832, 5.47785329818726, 100, -1);

                // Assert
                Assert.Equal(false, results.Status);
            }
        }
    }
}