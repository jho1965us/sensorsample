//-------------------------------------------------------------------------------
// <copyright file="PanicModeTargetLevelOracle.cs" company="Appccelerate">
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

namespace SensorSample.Evaluation
{
    using Appccelerate.EvaluationEngine;

    using SensorSample.Sirius;

    public class PanicModeTargetLevelOracle : IEvaluationEngineModule
    {
        public void Load(ISolutionDefinitionHost solutionDefinitionHost)
        {
            // TODO: extend the solution definition so that it takes into consideration whether panic mode is enabled (use property on question)
            solutionDefinitionHost.SolveWhereDoesThePassengerWantToTravelTo()
                .ByEvaluating((question, inPanicMode) => inPanicMode ? 0 : default(int?));
        }
    }
}