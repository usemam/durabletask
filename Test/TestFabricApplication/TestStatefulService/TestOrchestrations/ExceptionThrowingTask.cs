﻿//  ----------------------------------------------------------------------------------
//  Copyright Microsoft Corporation
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  ----------------------------------------------------------------------------------

using DurableTask.Core;

namespace TestStatefulService.TestOrchestrations
{
    class ExceptionThrowingTask : TaskActivity<int, bool>
    {
        protected override bool Execute(TaskContext context, int remainingAttempts)
        {
            if (remainingAttempts > 0)
            {
                ServiceEventSource.Current.Message($"{nameof(ExceptionThrowingTask)}.{nameof(Execute)} : Throwing Exception, RemainingAttempts = {remainingAttempts}");
                throw new CounterException(remainingAttempts);
            }

            ServiceEventSource.Current.Message($"{nameof(ExceptionThrowingTask)}.{nameof(Execute)} : Returning true, RemainingAttempts = {remainingAttempts}");
            return true;
        }
    }
}