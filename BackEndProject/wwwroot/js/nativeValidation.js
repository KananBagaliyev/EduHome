let form = document.querySelector("#form")

function("editor")
{
    let editor = document.querySelectorAll("editor")
}


form.onsubmit = function(event,minlength=10,maxlength=Infinity)
{
    for(var i=0;i< editors.length;++i)
    {
        if(editor[i].innerHTML.trim == "")
        {
            this.previousElementSibling.innerHTML = "This Field is required";
            return;
        }
        if(editor[i].innerHTML.trim.length < minlength)
        {
            this.previousElementSibling.innerHTML = "The minimum length must be" + minlength;
            return;
        }
        if(maxlength != Infinity)
        {
            if(editor[i].innerHTML.trim >maxlength)
            {
                this.previousElementSibling.innerHTML = "The maximum lenght must be" + maxlength;
                return;
            }
        }
        
    }
}