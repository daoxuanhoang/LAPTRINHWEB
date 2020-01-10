/// <reference path="../ckfinder/ckfinder.html" />
/// <reference path="../ckfinder/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.syntaxhightlight_lang = 'csharp';
    config.syntaxhightlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowserUrl = '/assets/Plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowserUrl = '/assets/Plugins/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowserUrl = '/assets/Plugins/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/assets/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserImageUploadUrl = '/assets/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/assets/Plugins/ckfinder/')
};
