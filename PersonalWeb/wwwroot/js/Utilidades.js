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