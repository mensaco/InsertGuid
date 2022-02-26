namespace InsertGuid
{
    [Command(PackageIds.MyInsertGuidCommand)]
    internal sealed class MyInsertGuidCommand : BaseCommand<MyInsertGuidCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {

            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selections = docView?.TextView.Selection.SelectedSpans;

            for (int i = selections.Count - 1; i >= 0; i--)
            {
                var selection = selections[i];
                docView.TextBuffer.Replace(selection, Guid.NewGuid().ToString());
            }
        }
    }
}
