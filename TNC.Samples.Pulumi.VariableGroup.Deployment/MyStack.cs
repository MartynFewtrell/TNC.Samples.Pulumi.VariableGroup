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

        var project = new AzureDevOps.Project("TNC.Samples", new AzureDevOps.ProjectArgs
        {

        });

    }

}

