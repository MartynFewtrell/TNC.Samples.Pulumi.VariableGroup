using Pulumi;
using Pulumi.AzureDevOps;
using Pulumi.AzureNative.Resources;
using System;
using AzureDevOps = Pulumi.AzureDevOps;

class MyStack : Stack
{
    public MyStack()
    {
        var resourceGroupName = "Logged value";
        Pulumi.Log.Info(resourceGroupName);

        var outputValue = Environment.GetEnvironmentVariable("AZDO_ORG_SERVICE_URL");
        if (outputValue != null)
        {
            Pulumi.Log.Info(outputValue);
        }

        var project = new AzureDevOps.Project("TNC.TestProject", new AzureDevOps.ProjectArgs
        {
            Name = "TNC.TestProject",
        });

        var variablegroup = new AzureDevOps.VariableGroup("VariableGroup.Test", new AzureDevOps.VariableGroupArgs
        {
            Name = "VariableGroup.Test",
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

