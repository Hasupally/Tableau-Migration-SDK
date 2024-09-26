﻿//
//  Copyright (c) 2024, Salesforce, Inc.
//  SPDX-License-Identifier: Apache-2
//  
//  Licensed under the Apache License, Version 2.0 (the "License") 
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//  http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System.IO;
using Tableau.Migration.Api.Models;
using Tableau.Migration.Api.Rest.Models.Types;
using Tableau.Migration.Content;
using Xunit;

namespace Tableau.Migration.Tests.Unit.Api.Models
{
    public class PublishDataSourceOptionsTests : AutoFixtureTestBase
    {
        private static void AssertContentTypeFields(IPublishableDataSource dataSource, PublishDataSourceOptions result)
        {
            Assert.Equal(dataSource.Name, result.Name);
            Assert.Equal(dataSource.Description, result.Description);
            Assert.Equal(dataSource.UseRemoteQueryAgent, result.UseRemoteQueryAgent);
            Assert.Equal(dataSource.EncryptExtracts, result.EncryptExtracts);
            Assert.Equal(((IContainerContent)dataSource).Container.Id, result.ProjectId);
        }

        [Fact]
        public void Default()
        {
            var dataSource = Create<IPublishableDataSource>();
            var testFile = Create<Stream>();
            var result = new PublishDataSourceOptions(dataSource, testFile);

            Assert.NotNull(result);
            AssertContentTypeFields(dataSource, result);
            Assert.Equal(testFile, result.File);
            Assert.Equal(dataSource.File.OriginalFileName, result.FileName);
            Assert.Equal(DataSourceFileTypes.Tdsx, result.FileType);
        }

        [Fact]
        public void Different_FileType()
        {
            var dataSource = Create<IPublishableDataSource>();
            var testFile = Create<Stream>();
            var testFileType = Create<string>();
            var result = new PublishDataSourceOptions(dataSource, testFile, testFileType);

            Assert.NotNull(result);
            AssertContentTypeFields(dataSource, result);
            Assert.Equal(testFile, result.File);
            Assert.Equal(dataSource.File.OriginalFileName, result.FileName);
            Assert.Equal(testFileType, result.FileType);
        }
    }
}
