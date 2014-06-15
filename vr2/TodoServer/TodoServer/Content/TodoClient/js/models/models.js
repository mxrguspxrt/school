var Yo = function(){}

Yo.View = function(opts){
  this.template = Handlebars.compile(opts["html"]);
}

Yo.View.prototype.render = function(opts){
  var renderedHtml = this.template(opts["values"]);
  return $(opts["element"]).html(renderedHtml);
}

Yo.Resource = function(opts){
  this.opts = opts;
  this.url = url;
  this.dataType = "json";
}

Yo.Resource.prototype.all = function(success, error){
  return $.ajax({type: "GET", url: this.url, dataType: this.dataType, success: success, error: error});
}

Yo.Resource.prototype.find = function(id, success, error){
  return $.ajax({type: "GET", url: this.url+"/"+id, dataType: this.dataType, success: success, error: error});
}

Yo.Resource.prototype.create = function(data, success, error){
  return $.ajax({type: "POST", url: this.url, dataType: this.dataType, data: data, success: success, error: error});
}

Yo.Resource.prototype.update = function(data, success, error){
  return $.ajax({type: "PUT", url: this.url+"/"+data.id, dataType: this.dataType, data: data, success: success, error: error});
}

Yo.Resource.prototype.delete = function(id, success, error){
  return $.ajax({type: "DELETE", url: this.url+"/"+data.id, dataType: "json", success: success, error: error});
}



//var App = function(){}
//var success = function(data){ alert(JSON.stringify(data)); }
//var error = function(data){ alert(JSON.stringify(data)); }

// App.Todo = new App.Resources("/api/todos");
// App.Task = new App.Resources("/api/tasks");

//App.Task.create({Headline: "Pealkiri", Description: "Kirjeldus", State: "Olek"}, success, error);
//App.Todo.create({TaskId: 1, Headline: "Pealkiri", Description: "Kirjeldus", State: "Olek"}, success, error);

// App.Todo.all(success, error);
// App.Todo.find(2, success, error);
// App.Todo.create({Headline: "Pealkiri", Description: "Kirjeldus", State: "Olek"})
// App.Todo.create({Headline: "Pealkiri", Description: "Kirjeldus", State: "Olek"})


//var tasksLoaded = function(tasks){
//  for(i=0; i<tasks.length; i++){
//    $("#tasks").append("<li>"+tasks[i].Headline+" "+tasks[i].Description+" "+tasks[i].State+" "+"</li>")
//  }
//}

//var createTask = function(){
//  var headline = $("#headline").val();
//  var description = $("#description").val();
//  var state = $("#state").val();
//  App.Task.create({Headline: headline, Description: description, State: state}, success, error)
//}

//var setup = function(){
//  App.Task.all(tasksLoaded, error);
//}

//$(document).ready(setup);
