Ext.define('Demo.view.Form', {
    extend: 'Ext.form.Panel',

    config: {
        title: 'Form',
        items: [
            {
                xtype: 'fieldset',
                title: 'Contact Information',
                defaults: {
                    labelWidth: '6em'
                },
                items: [
                    {
                        xtype: 'textfield',
                        label: 'First Name',
                        name: 'FirstName'
                    },
                    {
                        xtype: 'textfield',
                        label: 'Last Name',
                        name: 'LastName'
                    },
                    {
                        xtype: 'emailfield',
                        label: 'Email',
                        name: 'Email'
                    },
                    {
                        xtype: 'datepickerfield',
                        label: 'Birth Date',
                        name: 'BirthDate'
                    },
                    {
                        xtype: 'checkboxfield',
                        label: 'Favourite',
                        name: 'IsFavourite'
                    }
                ]
            },
            {
                xtype: 'toolbar',
                docked: 'bottom',
                ui: 'light',
                items: [
                    {
                        xtype: 'button',
                        text: 'Load',
                        align: 'left'
                    },
                    {
                        xtype: 'spacer'
                    },
                    {
                        xtype: 'button',
                        text: 'Save',
                        ui: 'confirm',
                        align: 'right'  
                    }
                ]
            }
        ]
    }
})