
# Weather Import
Technical Test for Theta Internship

## Approach
I built a C# Console App in Visual Studio 2017. The .sln file is also available on the GitHub repo.

After looking at the data, it was noted that while only 3 data points were important for the task, there was also an indication that this would become part of a larger and more regular file import. As a result, a decision was to create an app with the following structure:

* Program class to run the application
* Controller class to facilitate file loading and displaying of the functional outputs to the Console
* A Day class to manage the import of the Day data and to hold the data points
* A Month class to manage the import of the Monthly data, to hold all the days and some functions

## Assumptions
* Column lengths would always remain the same
* 3 data columns could contain blank or `null` values, so an assumption was made that this could occur in any column - all `int` and `double` values use the `Nullable<T>` type
* Some assumptions were made about what the saved data types should be (`double` vs `int` vs `string`)
* Data points for the Month fields (averages vs. sums)
* 3 columns had one data point with a star - an assumption was made that these represented either the highest or lowest values in those columns for the month - this was stored as a boolean

## Issues
Initially had issues accessing the file from the root directory; however, this was fixed by updating the file's properties. I am not sure if this will carryover to GitHub, so please let me know if there are any issues.

## Running the application
The application will load the file and confirm the month and number of days. It will then display the day with the minimum difference in temperature (should be June 14th). Then, as an extra exercise, it will display all the days with HDDay data to show that other data has loaded successfully, and `null` values handled.

## Theoretical Next Steps
* Confirm with the client which columns should never contain `null` data.
* Confirm the data types are correct - are there any that need changing?
* Confirm the meaning behind the column headers - update field names where appropriate
* Request test data from other months
* Confirm other required functions, including user input
