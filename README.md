#### Aggregation
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
Count | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$count" : "count" }
Limit | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$limit" : 2 }
Match | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$match" : { "Name" : "64fa63723ece47db89491e88cb7b5f2e" } }
Project | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Name" : "$Name", "_id" : 0 } }
Sample | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$sample" : { "size" : 2 } }
Skip | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$skip" : 1 }
Sort | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$sort" : { "Name" : 1 } }
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
In | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$in" : ["56617b2e3d4447ebad3d9fa2e2f78a48", "$StringArray"] } } }
IndexOfArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$project" : { "Result" : { "$indexOfArray" : ["$StringArray", "c656a93a852e4d68aab41f11ec0876a6"] } } }
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
AnyEq_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : "1901c12933894f518d3f48b946fd0ca7" }
AnyGt_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$gt" : 5 } }
AnyGte_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$gte" : 6 } }
AnyIn_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : { "$in" : ["ac1b8eea72e44e3cb3d54727176ba5ab", "1901c12933894f518d3f48b946fd0ca7"] } }
AnyLt_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$lt" : 2 } }
AnyLte_IntArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "IntArray" : { "$lte" : 1 } }
AnyNe_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : { "$ne" : "1901c12933894f518d3f48b946fd0ca7" } }
AnyNin_StringArray | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "StringArray" : { "$nin" : ["8c258b972c4d4aa695c01185cb6d7d6b", "1901c12933894f518d3f48b946fd0ca7", "71e51bed915a403dbb821e76f7f27bac", "a91060067baa4e3ea77f41aeb2a3d6a2", "2a3c74c3f221449fb973c4212b3fdcdf"] } }
<br/>

#### Simple
Test | Native | Cosmos | Query
--- | :---: | :---: | ---
And | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "_id" : CSUUID("6dab586d-15d5-4c7b-97eb-a0c45cc3cfe8"), "Name" : "1148cb28f61c4e9e8bd064e937a87873" }
Eq_ArrayOfSubDocuments | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "DocumentArray.Value" : "b4f96d3f643845a1b2a11b937bd66e97" }
Eq_SubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "Inner.Value" : "beb774fdaf704af18dc8219605abc7c6" }
Eq_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "Name" : "1148cb28f61c4e9e8bd064e937a87873" }
Ne_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "Name" : { "$ne" : "1148cb28f61c4e9e8bd064e937a87873" } }
NotEq_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "Name" : { "$ne" : "1148cb28f61c4e9e8bd064e937a87873" } }
Or | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "$or" : [{ "_id" : CSUUID("6dab586d-15d5-4c7b-97eb-a0c45cc3cfe8") }, { "_id" : CSUUID("bef16e36-c74a-4e79-91dd-44197018d7b6") }] }
Regex_ArrayOfSubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "DocumentArray" : { "$elemMatch" : { "Value" : /^b4f96d3f64/ } } }
Regex_SubDocument | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "Inner.Value" : /^beb774fdaf/ }
Regex_TopLevel | ![Pass](/CosmosDb.MongoDbTests.CreateReadmeMd/pass.png?raw=true) | ![Fail](/CosmosDb.MongoDbTests.CreateReadmeMd/fail.png?raw=true) | { "Name" : /^1148cb28f6/ }
<br/>

