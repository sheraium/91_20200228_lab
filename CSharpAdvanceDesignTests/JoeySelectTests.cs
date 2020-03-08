﻿using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    //[Ignore("not yet")]
    public class JoeySelectTests
    {
        [Test]
        public void replace_http_to_https()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelect(current => current.Replace("http:", "https:"));
            var expected = new List<string>
            {
                "https://tw.yahoo.com",
                "https://facebook.com",
                "https://twitter.com",
                "https://github.com",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void append_port_9191_urls()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelect(x => x + ":9191");
            var expected = new List<string>
            {
                "http://tw.yahoo.com:9191",
                "https://facebook.com:9191",
                "https://twitter.com:9191",
                "http://github.com:9191",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void select_with_seq_no()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelect((current, index) => $"{index + 1}. {current}");
            var expected = new List<string>
            {
                "1. http://tw.yahoo.com",
                "2. https://facebook.com",
                "3. https://twitter.com",
                "4. http://github.com",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }
        [Test]
        public void get_full_name_of_employees()
        {
            var employees = GetEmployees();
            var actual = JoeySelect(employees, e => $"{e.FirstName} {e.LastName}");
            var expected = new[]
            {
                "Joey Chen",
                "Tom Li",
                "David Chen",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<string> JoeySelect(IEnumerable source, Func<Employee, string> selector)
        {
            throw new NotImplementedException();
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
        }

        private static IEnumerable<string> GetUrls()
        {
            yield return "http://tw.yahoo.com";
            yield return "https://facebook.com";
            yield return "https://twitter.com";
            yield return "http://github.com";
        }
    }
}