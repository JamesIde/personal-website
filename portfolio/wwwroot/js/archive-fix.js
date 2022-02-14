const target = document.getElementById("section-toggler");
const archive = document.getElementById("archive-toggler");
const btnArchive = document.getElementById("toggle-archive");

var isActive = true;

btnArchive.onclick = function () {
  if (isActive) {
    archive.style.display = "block";
    target.style.display = "none";
  } else{
    archive.style.display = "none";
    target.style.display = "block";
  }
  isActive = !isActive;
};
