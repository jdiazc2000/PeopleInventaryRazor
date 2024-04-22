function ExportExcel(FileName, base64File) {
    const link = document.createElement("a");
    link.download = FileName;

    /*link.href = "data:application/octet-stream;base64," + base64;*/
    link.href = "data:application/vnd.ms-excel;base64," + base64File;
    /* link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + base64Archivo;*/

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function showPdfInNewTab(base64Data, fileName) {
    let pdfWindow = window.open("");
    pdfWindow.document.write("<html<head><title>" + fileName + "</title><style>body{margin: 0px;}</style></head>");
    pdfWindow.document.write("<body><embed width='100%' height='100%' src='data:application/pdf;base64, " + encodeURI(base64Data) + "#toolbar=0&navpanes=0&scrollbar=0'></embed></body></html>");
    pdfWindow.document.close();
}