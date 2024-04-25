import React from 'react'

const WorkingSpaceHolder = ({ws, children }) => {
    return (
        <div className='flex flex-col gap-2'>
            {
                ws.isLoading ? "yükleniyor"
                    :
                    ws.workingSpace ? children
                        :
                        "Henüz bir çalışma alanı yok"
            }

        </div>
    )
}

export default WorkingSpaceHolder