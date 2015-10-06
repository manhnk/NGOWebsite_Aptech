

$(document).ready(function () {
	$('li img').on('click',function(){
		var src = $(this).attr('src');
		var img = '<img src="' + src + '" class="img-responsive"/>';
		var id = $(this).attr("id");
		var urlRoot = window.location.href.substr(0,window.location.href.toLowerCase().indexOf("admin/"));
		var urlDetail = urlRoot+"Admin/ImageGallery/Details/" + id;
		var urlEdit = urlRoot + "Admin/ImageGallery/Edit/" + id;
		var urlDelete = urlRoot + "Admin/ImageGallery/Delete/" + id;

		//start of new code new code
		var index = $(this).parent('li').index();   
		
		var html = '';
		html += img;                
		html += '<div style="height:25px;clear:both;display:block;">';
		html += '<a class="controls next" href="' + (index + 2) + '">Next &raquo;</a>';
		html += '<a class="controls previous" href="' + (index) + '">&laquo; Prev</a>';
		html += '<div style="margin-left:140px;float:left ;font-size: 11px;padding-top: 8px;font-weight: bold;">';
		html += '<a class="details" href="' + urlDetail + '">Detail</a> | ';
		html += '<a class="edit" href="' + urlEdit + '">Edit</a> | ';
		html += '<a class="delete" href="' + urlDelete + '">Delete</a>';
		html += '</div>';
		html += '</div>';
		
		$('#myModal').modal();
		$('#myModal').on('shown.bs.modal', function(){
			$('#myModal .modal-body').html(html);
			//new code
			$('a.controls').trigger('click');
		})
		$('#myModal').on('hidden.bs.modal', function(){
			$('#myModal .modal-body').html('');
		});
		
		
		
		
   });	
})
        
         
$(document).on('click', 'a.controls', function(){
	var index = $(this).attr('href');
	var src = $('ul.row li:nth-child(' + index + ') img').attr('src');
	var id = $('ul.row li:nth-child(' + index + ') img').attr('id');
	var urlRoot = window.location.href.substr(0, window.location.href.toLowerCase().indexOf("admin/"));
	var urlDetail = urlRoot + "Admin/ImageGallery/Details/" + id;
	var urlEdit = urlRoot + "Admin/ImageGallery/Edit/" + id;
	var urlDelete = urlRoot + "Admin/ImageGallery/Delete/" + id;
	$("a.details").attr('href', urlDetail);
	$("a.edit").attr('href', urlEdit);
	$("a.delete").attr('href', urlDelete);

	$('.modal-body img').attr('src', src);
	
	var newPrevIndex = parseInt(index) - 1; 
	var newNextIndex = parseInt(newPrevIndex) + 2; 
	
	if($(this).hasClass('previous')){               
		$(this).attr('href', newPrevIndex); 
		$('a.next').attr('href', newNextIndex);
	}else{
		$(this).attr('href', newNextIndex); 
		$('a.previous').attr('href', newPrevIndex);
	}
	
	var total = $('ul.row li').length + 1; 
	//hide next button
	if(total === newNextIndex){
		$('a.next').hide();
	}else{
		$('a.next').show()
	}            
	//hide previous button
	if(newPrevIndex === 0){
		$('a.previous').hide();
	}else{
		$('a.previous').show()
	}
	
	
	return false;
});