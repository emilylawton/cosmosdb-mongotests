#### Aggregation
Test | Native | Cosmos | Query | Notes 
--- | :---: | :---: | :---: | ---
Count | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$count" : "count" } | 
Limit | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$limit" : 2 } | 
Match | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$match" : { "Name" : "13a3c05b407f49de8ff9fe2314f0051d" } } | 
Project | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Name" : "$Name", "_id" : 0 } } | 
Sample | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$sample" : { "size" : 2 } } | Pending deployment
Skip | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$skip" : 1 } |
Sort | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$sort" : { "Name" : 1 } } | 
Unwind | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$unwind" : "$StringArray" } | 
<br/>

#### Group
Test | Native | Cosmos | Query | Notes
--- | :---: | :---: | :---: | ---
Push | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$group" : { "_id" : "$Name", "AllInnerDocuments" : { "$push" : "$Inner" } } } | Pending deployment
<br/>

#### ProjectArithmetic
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Abs | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$abs" : "$Value" }, "_id" : 0 } }
Add | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$add" : ["$Value", 5] }, "_id" : 0 } }
Ceiling | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$ceil" : { "$add" : ["$Value", 8.75] } }, "_id" : 0 } }
Divide | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$divide" : ["$Value", 2] }, "_id" : 0 } }
Exp | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$exp" : ["$Value"] }, "_id" : 0 } }
Floor | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$floor" : { "$add" : ["$Value", 8.75] } }, "_id" : 0 } }
Ln | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "_id" : 0, "Result" : { "$ln" : "$Value" } } }
Log10 | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$log10" : ["$Value"] }, "_id" : 0 } }
Mod | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$mod" : ["$Value", 3] }, "_id" : 0 } }
Multiply | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$multiply" : ["$Value", 3] }, "_id" : 0 } }
Pow | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$pow" : ["$Value", 2.0] }, "_id" : 0 } }
Project_Arithmetic_Log | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$ln" : ["$Value"] }, "_id" : 0 } }
Sqrt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$sqrt" : ["$Value"] }, "_id" : 0 } }
Subtract | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$subtract" : ["$Value", 5] }, "_id" : 0 } }
Trunc | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$trunc" : "$Value" }, "_id" : 0 } }
<br/>

#### ProjectArray
Test | Native | Cosmos | Query | Notes
--- | :---: | :---: | :---: | ---
ArrayElemAt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$arrayElemAt" : ["$StringArray", 1] }, "_id" : 0 } } | Pending deployment
ConcatArrays | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$concatArrays" : ["$IntArray", "$IntArray2"] }, "_id" : 0 } } | Pending deployment
Filter | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$filter" : { "input" : "$IntArray", "as" : "i", "cond" : { "$eq" : ["$$i", 77] } } }, "_id" : 0 } } | 
In | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$in" : ["95e1b24ee72440cd9a9169c54f89f386", "$StringArray"] } } } | Pending deployment
IndexOfArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$indexOfArray" : ["$StringArray", "bb0e5a4fbf3e4f7a9010443ff3c3a91a"] } } } | Pending deployment
IsArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$isArray" : ["$StringArray"] } } } | Pending deployment
Map | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$map" : { "input" : "$IntArray", "as" : "s", "in" : { "$add" : ["$$s", 2] } } }, "_id" : 0 } } | 
Range | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$range" : [0, "$Value"] } } } | 
Reduce | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$reduce" : { "input" : "$IntArray", "initialValue" : 0, "in" : { "$add" : ["$$value", "$$this"] } } } } } | 
ReverseArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$reverseArray" : "$StringArray" } } } | Pending deployment
Size | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$size" : "$StringArray" }, "_id" : 0 } } | Pending deployment
Slice | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$slice" : ["$StringArray", 2, 1] }, "_id" : 0 } } | Pending deployment
<br/>

#### ProjectBoolean
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
And | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$and" : [{ "$gt" : ["$Value", 50] }, { "$gt" : ["$Value", 75] }] }, "_id" : 0 } }
Eq | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$eq" : ["$Name", "ABC123"] }, "_id" : 0 } }
Gt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$gt" : ["$Value", 99] }, "_id" : 0 } }
Gte | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$gte" : ["$Value", 100] }, "_id" : 0 } }
Lt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$lt" : ["$Value", 101] }, "_id" : 0 } }
Lte | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$lte" : ["$Value", 100] }, "_id" : 0 } }
Ne | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$ne" : ["$Name", "ABC123"] }, "_id" : 0 } }
Not | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$not" : [{ "$gt" : ["$Value", 50] }] }, "_id" : 0 } }
Or | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$or" : [{ "$gt" : ["$Value", 50] }, { "$lt" : ["$Value", 2] }] }, "_id" : 0 } }
<br/>

#### ProjectString
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Concat | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$concat" : ["$Name", ":", "$Body"] }, "_id" : 0 } }
IndexOf | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$indexOfBytes" : ["$Name", "b"] }, "_id" : 0 } }
Split | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$split" : ["$Name", "."] }, "_id" : 0 } }
StringLength | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$strLenBytes" : "$Name" }, "_id" : 0 } }
Substring | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$substr" : ["$Name", 0, 3] }, "_id" : 0 } }
ToLower | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$toLower" : "$Name" }, "_id" : 0 } }
ToUpper | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Result" : { "$toUpper" : "$Name" }, "_id" : 0 } }
<br/>

#### ArraySingleValue
Test | Native | Cosmos | Query | Notes 
--- | :---: | :---: | :---: | ---
AnyEq_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "StringArray" : "2bdd3e742a0448eaad53655c5e696f4d" } |
AnyGt_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "IntArray" : { "$gt" : 5 } } | Supported with $elemMatch |
AnyGte_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "IntArray" : { "$gte" : 6 } } | Supported with $elemMatch |
AnyIn_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "StringArray" : { "$in" : ["400bdbebc5294391b7f17921669ac626", "2bdd3e742a0448eaad53655c5e696f4d"] } } | Supported with $elemMatch |
AnyLt_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "IntArray" : { "$lt" : 2 } } | Supported with $elemMatch
AnyLte_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "IntArray" : { "$lte" : 1 } } | Supported with $elemMatch
AnyNe_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "StringArray" : { "$ne" : "2bdd3e742a0448eaad53655c5e696f4d" } } |
AnyNin_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "StringArray" : { "$nin" : ["abc682b6a001491ea2ccb9cc8e06172f", "2bdd3e742a0448eaad53655c5e696f4d", "50c1aa4d28194e9396f017472ddda9ae", "daf6be06511140928e8d899782bdc0e0", "346dda52a59145568c08583c0395ae5f"] } } |
<br/>

#### Simple
Test | Native | Cosmos | Query | Notes
--- | :---: | :---: | :---: | ---
And | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "_id" : CSUUID("0025bfda-90a4-46a0-9ea9-952dc379bd41"), "Name" : "98ba1224a25e4e06af6e3b7152e9fbf3" } |
Eq_ArrayOfSubDocuments | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "DocumentArray.Value" : "49d4d3ea904f44b29163590d035e1779" } | Supported with $elemMatch
Eq_SubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Inner.Value" : "41c0433aa6584ca48d877ab5900b6a7e" } |
Eq_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : "98ba1224a25e4e06af6e3b7152e9fbf3" } |
Ne_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : { "$ne" : "98ba1224a25e4e06af6e3b7152e9fbf3" } } |
NotEq_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : { "$ne" : "98ba1224a25e4e06af6e3b7152e9fbf3" } } |
Or | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$or" : [{ "_id" : CSUUID("0025bfda-90a4-46a0-9ea9-952dc379bd41") }, { "_id" : CSUUID("403c33e1-0a46-4883-9c06-ff21bf046383") }] } |
Regex_ArrayOfSubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "DocumentArray" : { "$elemMatch" : { "Value" : /^49d4d3ea90/ } } } |
Regex_SubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Inner.Value" : /^41c0433aa6/ } |
Regex_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : /^98ba1224a2/ } |
<br/>

