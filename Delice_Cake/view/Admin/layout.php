<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <link rel="icon" href="public/img/logo-Delice.png" type="image/x-icon" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Delice Bakery</title>

    <!-- Icon css link -->
  <!--     Fonts and icons     -->
  <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700,200" rel="stylesheet" />
  <link href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" rel="stylesheet">
  <!-- CSS Files -->
  <link href="public/paper-dashboard-master/assets/css/bootstrap.min.css" rel="stylesheet" />
  <link href="public/paper-dashboard-master/assets/css/paper-dashboard.css?v=2.0.1" rel="stylesheet" />
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="public/paper-dashboard-master/assets/demo/demo.css" rel="stylesheet" />
      <link href="public/css/font-awesome.min.css" rel="stylesheet">
      

    <style>
		.font-large {
			font-size: 40px !important;
			
		}
	</style>
    <!-- <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css" rel="stylesheet"> -->
    
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <?php session_start(); ?>
	<?php require_once 'route.php'; ?>
   <script src="public/paper-dashboard-master/assets/js/core/jquery.min.js"></script>
  <script src="public/paper-dashboard-master/assets/js/core/popper.min.js"></script>
  <script src="public/paper-dashboard-master/assets/js/core/bootstrap.min.js"></script>
  <script src="public/paper-dashboard-master/assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/perfect-scrollbar@1.5.5/dist/perfect-scrollbar.min.js"></script>

  <!--  Google Maps Plugin    -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!-- Chart JS -->
  <script src="public/paper-dashboard-master/assets/js/plugins/chartjs.min.js"></script>
  <!--  Notifications Plugin    -->
  <script src="public/paper-dashboard-master/assets/js/plugins/bootstrap-notify.js"></script>
  <!-- Control Center for Now Ui Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="public/paper-dashboard-master/assets/js/paper-dashboard.min.js?v=2.0.1" type="text/javascript"></script><!-- Paper Dashboard DEMO methods, don't include it in your project! -->
  <script src="public/paper-dashboard-master/assets/demo/demo.js"></script>
    

    <script>
        function confirmLogout() {
            if (confirm("Do you want to logout?")) {
                window.location.href = "<?= BASE_URL ?>?controller=Login&action=logout";
            }
        }
    </script>
 <script>
    function SelectText(element) {
      var doc = document,
        text = element,
        range, selection;
      if (doc.body.createTextRange) {
        range = document.body.createTextRange();
        range.moveToElementText(text);
        range.select();
      } else if (window.getSelection) {
        selection = window.getSelection();
        range = document.createRange();
        range.selectNodeContents(text);
        selection.removeAllRanges();
        selection.addRange(range);
      }
    }
    window.onload = function() {
      var iconsWrapper = document.getElementById('icons-wrapper'),
        listItems = iconsWrapper.getElementsByTagName('li');
      for (var i = 0; i < listItems.length; i++) {
        listItems[i].onclick = function fun(event) {
          var selectedTagName = event.target.tagName.toLowerCase();
          if (selectedTagName == 'p' || selectedTagName == 'em') {
            SelectText(event.target);
          } else if (selectedTagName == 'input') {
            event.target.setSelectionRange(0, event.target.value.length);
          }
        }

        var beforeContentChar = window.getComputedStyle(listItems[i].getElementsByTagName('i')[0], '::before').getPropertyValue('content').replace(/'/g, "").replace(/"/g, ""),
          beforeContent = beforeContentChar.charCodeAt(0).toString(16);
        var beforeContentElement = document.createElement("em");
        beforeContentElement.textContent = "\\" + beforeContent;
        listItems[i].appendChild(beforeContentElement);

        //create input element to copy/paste chart
        var charCharac = document.createElement('input');
        charCharac.setAttribute('type', 'text');
        charCharac.setAttribute('maxlength', '1');
        charCharac.setAttribute('readonly', 'true');
        charCharac.setAttribute('value', beforeContentChar);
        listItems[i].appendChild(charCharac);
      }
    }
  </script>
  
</body>
</html>