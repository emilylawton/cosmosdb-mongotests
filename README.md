#### Aggregation
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Count | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$count" : "count" }
Limit | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$limit" : 2 }
Match | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$match" : { "Name" : "3237b975b8b242fea0299135fd8eda9e" } }
Project | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$project" : { "Name" : "$Name", "_id" : 0 } }
Sample | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$sample" : { "size" : 2 } }
Skip | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$skip" : 1 }
Sort | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$sort" : { "Name" : 1 } }
Unwind | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$unwind" : "$StringArray" }
<br/>
#### Group
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Push | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$group" : { "_id" : "$Name", "AllInnerDocuments" : { "$push" : "$Inner" } } }
<br/>
#### ProjectArithmetic
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Abs | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$abs" : "$Value" }, "_id" : 0 } }
Add | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$add" : ["$Value", 5] }, "_id" : 0 } }
Ceiling | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$ceil" : { "$add" : ["$Value", 8.75] } }, "_id" : 0 } }
Divide | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$divide" : ["$Value", 2] }, "_id" : 0 } }
Exp | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$exp" : ["$Value"] }, "_id" : 0 } }
Floor | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$floor" : { "$add" : ["$Value", 8.75] } }, "_id" : 0 } }
Ln | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "_id" : 0, "Result" : { "$ln" : "$Value" } } }
Log10 | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$log10" : ["$Value"] }, "_id" : 0 } }
Mod | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$mod" : ["$Value", 3] }, "_id" : 0 } }
Multiply | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$multiply" : ["$Value", 3] }, "_id" : 0 } }
Pow | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$pow" : ["$Value", 2.0] }, "_id" : 0 } }
Project_Arithmetic_Log | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$ln" : ["$Value"] }, "_id" : 0 } }
Sqrt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$sqrt" : ["$Value"] }, "_id" : 0 } }
Subtract | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$subtract" : ["$Value", 5] }, "_id" : 0 } }
Trunc | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$trunc" : "$Value" }, "_id" : 0 } }
<br/>
#### ProjectArray
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
ArrayElemAt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$arrayElemAt" : ["$StringArray", 1] }, "_id" : 0 } }
ConcatArrays | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$concatArrays" : ["$IntArray", "$IntArray2"] }, "_id" : 0 } }
Filter | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$filter" : { "input" : "$IntArray", "as" : "i", "cond" : { "$eq" : ["$$i", 77] } } }, "_id" : 0 } }
In | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$in" : ["207735099d574aa7a252a840cf662ea6", "$StringArray"] } } }
IndexOfArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$indexOfArray" : ["$StringArray", "9ce266a50a06490cbd3ece35a2684abe"] } } }
IsArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$isArray" : ["$StringArray"] } } }
Map | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$map" : { "input" : "$IntArray", "as" : "s", "in" : { "$add" : ["$$s", 2] } } }, "_id" : 0 } }
Range | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$range" : [0, "$Value"] } } }
Reduce | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$reduce" : { "input" : "$IntArray", "initialValue" : 0, "in" : { "$add" : ["$$value", "$$this"] } } } } }
ReverseArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$reverseArray" : "$StringArray" } } }
Size | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$size" : "$StringArray" }, "_id" : 0 } }
Slice | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$slice" : ["$StringArray", 2, 1] }, "_id" : 0 } }
<br/>
#### ProjectBoolean
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
And | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$and" : [{ "$gt" : ["$Value", 50] }, { "$gt" : ["$Value", 75] }] }, "_id" : 0 } }
Eq | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$eq" : ["$Name", "ABC123"] }, "_id" : 0 } }
Gt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$gt" : ["$Value", 99] }, "_id" : 0 } }
Gte | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$gte" : ["$Value", 100] }, "_id" : 0 } }
Lt | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$lt" : ["$Value", 101] }, "_id" : 0 } }
Lte | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$lte" : ["$Value", 100] }, "_id" : 0 } }
Ne | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$ne" : ["$Name", "ABC123"] }, "_id" : 0 } }
Not | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$not" : [{ "$gt" : ["$Value", 50] }] }, "_id" : 0 } }
Or | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$or" : [{ "$gt" : ["$Value", 50] }, { "$lt" : ["$Value", 2] }] }, "_id" : 0 } }
<br/>
#### ProjectString
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Concat | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$concat" : ["$Name", ":", "$Body"] }, "_id" : 0 } }
IndexOf | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$indexOfBytes" : ["$Name", "b"] }, "_id" : 0 } }
Split | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$split" : ["$Name", "."] }, "_id" : 0 } }
StringLength | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$strLenBytes" : "$Name" }, "_id" : 0 } }
Substring | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$substr" : ["$Name", 0, 3] }, "_id" : 0 } }
ToLower | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$toLower" : "$Name" }, "_id" : 0 } }
ToUpper | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$toUpper" : "$Name" }, "_id" : 0 } }
<br/>
#### ArraySingleValue
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
AnyEq_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : "9cfa9fb0a32142a38461b22eb9960324" }
AnyGt_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$gt" : 5 } }
AnyGte_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$gte" : 6 } }
AnyIn_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : { "$in" : ["ae196425000e4129b28e34d80fcfb793", "9cfa9fb0a32142a38461b22eb9960324"] } }
AnyLt_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$lt" : 2 } }
AnyLte_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$lte" : 1 } }
AnyNe_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : { "$ne" : "9cfa9fb0a32142a38461b22eb9960324" } }
AnyNin_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : { "$nin" : ["7c8cc51bcd654befbe610fde32e648ab", "9cfa9fb0a32142a38461b22eb9960324", "8c88d2661b544ec3bf9e2394e8d377e8", "895a4558b2c84c5886adf12ae290f3f3", "090e8430b76d4ce79e856bf27e1d78d9"] } }
<br/>
#### Simple
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
And | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "_id" : CSUUID("2e863e18-9bd3-41ea-aa8a-fe457e46e63e"), "Name" : "7f3c62c4c06a43acaf3d9a932ba8a31b" }
Eq_ArrayOfSubDocuments | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "DocumentArray.Value" : "3b42d939e3bf4472a6d231deca6b632c" }
Eq_SubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Inner.Value" : "b2d00d26857248719304989e199b8d58" }
Eq_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : "7f3c62c4c06a43acaf3d9a932ba8a31b" }
Ne_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : { "$ne" : "7f3c62c4c06a43acaf3d9a932ba8a31b" } }
NotEq_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : { "$ne" : "7f3c62c4c06a43acaf3d9a932ba8a31b" } }
Or | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "$or" : [{ "_id" : CSUUID("2e863e18-9bd3-41ea-aa8a-fe457e46e63e") }, { "_id" : CSUUID("1b3e824c-03ac-47f6-93cb-7bcf235c88fd") }] }
Regex_ArrayOfSubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "DocumentArray" : { "$elemMatch" : { "Value" : /^3b42d939e3/ } } }
Regex_SubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Inner.Value" : /^b2d00d2685/ }
Regex_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | { "Name" : /^7f3c62c4c0/ }
<br/>
