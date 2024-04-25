import { priorityConverter } from './priorityConverter';
export const taskDTC = [
    {
        name: 'Görev',
        cell: row => <div className='w-full lg:w-1/2 '>{row.title}</div>,
        selector: row => row.title,
        sortable: true
    },
    {
        name: 'Önem',
        cell: row => {
            let urgency = priorityConverter(row.priority)
            return (
                <div style={{ backgroundColor: urgency.color }} className='w-full lg:w-1/2 text-center pointer-events-none font-semibold p-1 rounded-xl'>{urgency.text}
                </div>
            )
        },

        selector: row => row.priority,
        sortable: true
    },
    {
        name: 'Durumu',
        cell: row => {
            let status = row.status
            return (
                <div style={{ backgroundColor: status.color }} className='w-full lg:w-1/2 text-center pointer-events-none font-semibold p-1 rounded-xl'>{status.displayText}
                </div>
            )
        },
        selector: row => row.status.id,
        sortable: true
    },
    {
        name: 'Bitiş tarihi',
        cell: row => {
            return (
                <span className={`break-keep w-max ${row.isOver && 'text-rose-500 font-extrabold underline'}`}>{row.endDate}


                </span>)
        },
        selector: row => row.endDate,
        sortable: true
    },

];


export const conditionalRowStyles = [
    {
        when: row => row.isOver,
        style: {
            "opacity": "0.5",
            "background-color": "#ffbbbb"
        }

    },

];