using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Model;
using ToyRobot.TableTops;
using Xunit;

namespace ToyRobot.Test
{
    public class TableTopTests
    {
        private readonly ITableTop _toyTable;

        public TableTopTests() => _toyTable = new Mock<TableTop>(5, 5).Object;

        [Fact]
        public void Check_Table_Position_Invalid()
        {
            // Assign
            var position = new Position(9, 7);

            // Act 
            var expected = _toyTable.MovetoNextPosition(position);

            // Assert
            expected.Should().BeFalse();
        }

        [Fact]
        public void Check_Table_Position_valid()
        {
            // Assign
            var position = new Position(2, 3);

            // Act 
            var expected = _toyTable.MovetoNextPosition(position);

            // Assert
            expected.Should().BeTrue();
        }
    }
}
