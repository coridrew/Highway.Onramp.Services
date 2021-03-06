// [[Highway.Onramp.Services.Data]]
// Copyright 2013 Timothy J. Rayburn
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using Castle.Core.Logging;
using Highway.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Templates.Abstractions
{
    public interface IRepositoryFactory
    {
        IRepository CreateRepository();
        void ReleaseRepository(IRepository repo);
    }

    public static class RepositoryFactoryExtensions
    {
        public static void With(this IRepositoryFactory factory, Action<IRepository> action)
        {
            var repo = factory.CreateRepository();
            try
            {
                action.Invoke(repo);
            }
            finally
            {
                factory.ReleaseRepository(repo);
            }
        }
    }
}
