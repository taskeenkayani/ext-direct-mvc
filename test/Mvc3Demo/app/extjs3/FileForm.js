Ext.ux.FileForm = Ext.extend(Ext.form.FormPanel, {
    title: 'File Upload Form',
    padding: 10,
    labelWidth: 80,
    fileUpload: true, // <- IMPORTANT
    defaults: {
        anchor: '100%',
        xtype: 'fileuploadfield'
    },
    
    initComponent: function() {
        var config = {
            api: {
                submit: Form.Upload
            },
            items: [
                { fieldLabel: 'File #1' },
                { fieldLabel: 'File #2' },
                { fieldLabel: 'File #3' }
            ],
            
            bbar: ['->', {
                text: 'Upload Files',
                handler: function() {
                    this.getForm().submit({
                        success: function(form, action) {
                            Ext.Msg.alert('Done', 'Files uploaded successfully!<br/>You can find them in "Uploaded Files" folder.');
                        }
                    });
                },
                scope: this
            }]
        };
        Ext.apply(this, Ext.apply(this.initialConfig, config));
        
        Ext.ux.FileForm.superclass.initComponent.call(this);
    }
});