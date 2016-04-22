/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';


    config.filebrowserImageBrowseUrl = 'editor/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = 'editor/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = 'editor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = 'editor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = 'editor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.filebrowserWindowWidth = '800';
    config.filebrowserWindowHeight = '500';
};
