import React from 'react'
import DataTable from 'react-data-table-component'
import ExpandedRowComponent from './ExpandedRowComponent'
import { conditionalRowStyles, taskDTC } from '../../../../../utilities/taskDataTableColumns'

const WorkingSpaceDataTable = ({taskList}) => {
    return (
        <div className='p-5 flex flex-col gap-2'>
            <DataTable
                onRowClicked={(row, event) => { alert(row.id) }}
                expandableRowsComponent={ExpandedRowComponent}
                expandableRows
                paginationPerPage={4}
          paginationRowsPerPageOptions={[2, 4, 8]}
                highlightOnHover
                striped
                title="Görev listesi"
                pagination
                conditionalRowStyles={conditionalRowStyles}
                columns={taskDTC}
                data={taskList}
            />
        </div>
    )
}

export default WorkingSpaceDataTable