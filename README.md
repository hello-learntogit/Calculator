# Summary
A simple program to accept an expression as a String parameter and return the calculated result. It takes 2 days ( 17 - 18 June 2022 ) for the completion.

# Assumption
- Assume the argument always consist of numbers and operators separated by space.
- operator that mention on following are +, -, *, / only.
- The program only resolve for mentioned expression: 
	- single operator : 1 + 1
	- multiple operator : 1 + 2 * 3 / 4
	- single bracket expression : ( 1 + 2 ) / 3
	- multiple bracket expression : ( 1 + 1 ) ( 2 * 2)
	- nested bracket expression : ( 2 + 3 * ( 4 - 5 ))
# Constraints
The current known expression pattern that still not able to solve as follow:
- 3(2)

# Step to test the program:
- replace_with_the_expression_to_test: Kindly refer Argument_Sample.txt
- directory_of_Calculator_project_src_folder:  C:\Users\\%UserProfile%\source\repos\Calculator\src

1. open cmd
2. cd "directory_of_Calculator_project_src_folder"
3. dotnet run --project "./Calculator/Calculator.csproj" "replace_with_the_expression_to_test"
- To execute the unit test:
4. dotnet test "./Calculator.UnitTest/Calculator.UnitTest.csproj"