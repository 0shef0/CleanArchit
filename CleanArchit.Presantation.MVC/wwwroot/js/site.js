// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function EditTask() {

    let ch = document.getElementById("checkbox-task");
    
    //alert(ch);
    //window.location.href = '@Url.Action("TaskInfo", "task")/' + ch;
    //window.location.href = '@Url.Action("TaskInfo", "task")';
    
}

//$("#checkbox-task").click(function () {
//    alert("fjgjszh");
//    let ch = document.getElementById("checkbox-task").checked;
//    alert(ch);
//    alert(";sHFfjkh");
//    window.location.href = '@Url.Action("TaskInfo", "task")/' + ch;
//});

//<a asp-action="TaskInfo" asp-controller="task" asp-route-id="@Model.Tasks.ToList()[index].ID">Detail info</a>

/* Set the width of the sidebar to 250px and the left margin of the page content to 250px */
function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}