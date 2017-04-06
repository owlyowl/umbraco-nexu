﻿namespace Our.Umbraco.Nexu.Parsers.Tests.PropertyParsers.Core
{
    using System.Linq;

    using global::Umbraco.Core.Models;

    using NUnit.Framework;

    using Our.Umbraco.Nexu.Core.Enums;
    using Our.Umbraco.Nexu.Parsers.PropertyParsers.Core;

    /// <summary>
    /// The content picker parser tests.
    /// </summary>
    [TestFixture]
    public class ContentPickerParserTests : BaseParserTest
    {        
        /// <summary>
        /// The test is parser for valid data type.
        /// </summary>
        [Test]
        [Category("PropertyParsers")]
        [Category("CorePropertyParsers")]
        public void TestIsParserForValidDataType()
        {
            // arrange
            var dataTypeDefinition = new DataTypeDefinition(global::Umbraco.Core.Constants.PropertyEditors.ContentPickerAlias);

            var parser = new ContentPickerParser();

            // act
            var result = parser.IsParserFor(dataTypeDefinition);

            // verify
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The test is parser for valid data type for Umbraco 7.6
        /// </summary>
        [Test]
        [Category("PropertyParsers")]
        [Category("CorePropertyParsers")]
        public void TestIsParserForValidDataTypeV76()
        {
            // arrange
            var dataTypeDefinition = new DataTypeDefinition("Umbraco.ContentPicker2");

            var parser = new ContentPickerParser();

            // act
            var result = parser.IsParserFor(dataTypeDefinition);

            // verify
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The test is parser for in valid data type.
        /// </summary>
        [Test]
        [Category("PropertyParsers")]
        [Category("CorePropertyParsers")]
        public void TestIsParserForInValidDataType()
        {
            // arrange
            var dataTypeDefinition = new DataTypeDefinition("foo");

            var parser = new ContentPickerParser();

            // act
            var result = parser.IsParserFor(dataTypeDefinition);

            // verify
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test getting linked entities with a value
        /// </summary>
        [Test]
        [Category("PropertyParsers")]
        [Category("CorePropertyParsers")]
        public void TestGetLinkedEntitiesWithValue()
        {
            // arrange
            var parser = new ContentPickerParser();

            var propertyType = new PropertyType(
                              global::Umbraco.Core.Constants.PropertyEditors.ContentPickerAlias,
                              DataTypeDatabaseType.Integer,
                              "cp1");

            var property = new Property(propertyType, 1500);

            // act
            var result = parser.GetLinkedEntities(property.Value);

            // verify
            Assert.IsNotNull(result);
            var entities = result.ToList();
            Assert.AreEqual(1, entities.Count());

            var entity = entities.First();

            Assert.AreEqual(LinkedEntityType.Document, entity.LinkedEntityType);
            Assert.AreEqual(1500, entity.Id);
        }

        /// <summary>
        /// Test getting linked entities with a empty value
        /// </summary>
        [Test]
        [Category("PropertyParsers")]
        [Category("CorePropertyParsers")]
        public void TestGetLinkedEntitiesWithEmptyValue()
        {
            // arrange
            var parser = new ContentPickerParser();

            var propertyType = new PropertyType(
                              global::Umbraco.Core.Constants.PropertyEditors.ContentPickerAlias,
                              DataTypeDatabaseType.Integer,
                              "cp1");

            var property = new Property(propertyType, null);

            // act
            var result = parser.GetLinkedEntities(property.Value);

            // verify
            Assert.IsNotNull(result);
            var entities = result.ToList();
            Assert.AreEqual(0, entities.Count());           
        }
    }
}