﻿#region License
//  Copyright 2004-2010 Castle Project - http:www.castleproject.org/
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http:www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// 
#endregion

namespace test.SpecFlowPlugin.CodeDomExtensions
{
	using System.CodeDom;

	public static class CodeExpressionCollectionExtensions
    {
        public static CodeExpressionCollection Clone(this CodeExpressionCollection collection)
        {
            if (collection == null) return null;
            CodeExpressionCollection c = new CodeExpressionCollection();
            foreach (CodeExpression expression in collection)
                c.Add(expression.Clone());
            return c;
        }

        public static void ReplaceType(this CodeExpressionCollection collection, string oldType, string newType)
        {
            if (collection == null) return;
            foreach (CodeExpression expression in collection)
                expression.ReplaceType(oldType, newType);
        }
    }
}
