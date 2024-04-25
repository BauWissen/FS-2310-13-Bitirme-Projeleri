import React from 'react'

const ExpandedRowComponent = ({ data }) => {
    return (
        <div className='p-2 border-y-2 bg-slate-100 border-slate-300 '>
            {
                data.userList.map((u) => {
                    return (
                        <div key={u.id}>
                            {u.firstName}
                        </div>
                    )
                })}
        </div>
    )
}

export default ExpandedRowComponent