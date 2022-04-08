
var modal = document.getElementById("myModal");

var img = document.getElementById("myImg");
var modalImg = document.getElementById("img01");
img.onclick = function(){
  modal.style.display = "block";
  modalImg.src = this.src;
  
}

var span = document.getElementsByClassName("close")[0];

span.onclick = function() {
  modal.style.display = "none";
}

var img2 = document.getElementById("myImg2");
img2.onclick = function(){
  modal.style.display = "block";
  modalImg.src = this.src;
  
}

var img3 = document.getElementById("myImg3");
img3.onclick = function(){
  modal.style.display = "block";
  modalImg.src = this.src;
  
}
