using Pulumi;
using Pulumi.AzureDevOps;
using Pulumi.AzureNative.Resources;
using AzureDevOps = Pulumi.AzureDevOps;

class MyStack : Stack
{

    public MyStack()
    {
        var resourceGroupName = "Logged value";
        Pulumi.Log.Info(resourceGroupName);

        var project = new AzureDevOps.Project("project", new AzureDevOps.ProjectArgs
        {
        });
        var variablegroup = new AzureDevOps.VariableGroup("variablegroup", new AzureDevOps.VariableGroupArgs
        {
            ProjectId = project.Id,
            Description = "Test Variable Group Description",
            AllowAccess = true,
            Variables =
            {
                new AzureDevOps.Inputs.VariableGroupVariableArgs
                {
                    Name = "key",
                    Value = "value",
                },
                new AzureDevOps.Inputs.VariableGroupVariableArgs
                {
                    Name = "Account Password",
                    SecretValue = "p@ssword123",
                    IsSecret = true,
                },
            },
        });

    }

}

