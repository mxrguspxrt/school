function validateSingleDestination(theForm,formNum,bRequired){var gotoType=theForm.elements['goto'+formNum].value;if(bRequired&&gotoType==''){alert('Please select a "Destination"');return false;}else{if(gotoType=='custom'){var gotoFld=theForm.elements['custom'+formNum];var gotoVal=gotoFld.value;if(gotoVal.indexOf('custom-')==-1){alert('Custom Goto contexts must contain the string "custom-".  ie: custom-app,s,1');gotoFld.focus();return false;}}}
return true;}

// Used on the extensions/devices page to make sure a strong password is used
function weakSecret()
{
  var password = document.getElementById('devinfo_secret').value;
  var origional_password = document.getElementById('devinfo_secret_origional').value;

  if (password == origional_password)
  {
    return false;
  }

  if (password.length <= 5)
  {
    alert('The secret must be at minimum six characters in length.');
    return true;
  }

  if (password.match(/[a-z].*[a-z]/i) == null || password.match(/\d\D*\d/) == null)
  {
    alert('The secret must contain at least two numbers and two letters.');
    return true;
  }
  return false;
}
