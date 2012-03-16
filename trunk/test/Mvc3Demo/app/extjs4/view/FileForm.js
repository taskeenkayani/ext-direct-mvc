Ext.define('Demo.view.FileForm', {
    extend: 'Ext.form.Panel',
    title: 'File Upload Form',
    bodyPadding: 10,
    defaults: {
        xtype: 'filefield',
        anchor: '100%',
        labelWidth: 80
    },
    items: [
        { fieldLabel: 'File #1' },
        { fieldLabel: 'File #2' },
        { fieldLabel: 'File #3' }
    ],
    bbar: ['->',
        { text: 'Upload Files', itemId: 'uploadButton' }
    ],

    initComponent: function () {
        var config = {
            api: {
                submit: Form.Upload
            }
        };
        
        Ext.apply(this, Ext.apply(this.initialConfig, config));

        this.callParent();

        this.down('#uploadButton').on('click', this.onUploadClick, this);
    },
    
    onUploadClick: function () {
        this.getForm().submit({
            success: function(form, action) {
                Ext.Msg.alert('Done', 'Files uploaded successfully!<br/>You can find them in "Uploaded Files" folder.');
            }
        });
    }
});