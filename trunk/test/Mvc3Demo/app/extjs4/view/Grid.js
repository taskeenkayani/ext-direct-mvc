Ext.define('Demo.view.Grid', {
    extend: 'Ext.grid.Panel',
    title: 'Contacts',
    frame: true,
    stripeRows: true,
    store: 'Contacts',
    columns: [
        {text: 'First Name', dataIndex: 'FirstName', flex: 1},
        {text: 'Last Name', dataIndex: 'LastName', flex: 1},
        {text: 'Birth Date', dataIndex: 'BirthDate', xtype: 'datecolumn', format: 'm/d/Y'},
        {text: 'Employeed', dataIndex: 'Employed', xtype: 'booleancolumn', trueText: 'Yes', falseText: 'No', align: 'center'}
    ],
    dockedItems: [
        {
            xtype: 'pagingtoolbar',
            store: 'Contacts',
            dock: 'bottom',
            displayInfo: true
        }
    ]
});