﻿//-------------------------------------------------------------------------------
// <copyright file="BootstrapperStrategy.cs" company="Appccelerate">
//   Copyright (c) 2008-2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SensorSample
{
    using Appccelerate.Bootstrapper;
    using Appccelerate.Bootstrapper.Syntax;
    using Appccelerate.EventBroker;

    public class BootstrapperStrategy : AbstractStrategy<ISensor>
    {
        private IEventBroker globalEventBroker;

        public BootstrapperStrategy()
        {
            this.globalEventBroker = new EventBroker();
        }

        public override IExtensionResolver<ISensor> CreateExtensionResolver()
        {
            return new SensorResolver();
        }

        protected override void DefineRunSyntax(ISyntaxBuilder<ISensor> builder)
        {
            builder
                .Execute(sensor => sensor.StartObservation())
                    .With(new RegisterOnEventBrokerBehavior(this.globalEventBroker));
        }

        protected override void DefineShutdownSyntax(ISyntaxBuilder<ISensor> builder)
        {
            builder
                .Execute(sensor => sensor.StopObservation())
            .End
                .With(new UnregisterOnEventBrokerBehavior(this.globalEventBroker));
        }
    }
}