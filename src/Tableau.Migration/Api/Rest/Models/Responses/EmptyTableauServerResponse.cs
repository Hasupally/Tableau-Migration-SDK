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

using System.Xml.Serialization;

namespace Tableau.Migration.Api.Rest.Models.Responses
{
    /// <summary>
    /// Empty container class for Tableau Server responses
    /// </summary>
    [XmlType(XmlTypeName)]
    public class EmptyTableauServerResponse : TableauServerResponse
    {
        /// <summary>
        /// Creates a new <see cref="EmptyTableauServerResponse"/> instance.
        /// </summary>
        public EmptyTableauServerResponse()
            : base()
        { }

        /// <summary>
        /// Creates a new <see cref="EmptyTableauServerResponse"/> instance.
        /// </summary>
        /// <param name="error">The error for the response</param>
        internal EmptyTableauServerResponse(Error error)
            : base(error)
        { }
    }
}
