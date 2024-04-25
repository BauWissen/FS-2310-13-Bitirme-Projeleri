import React from 'react'

const PageLayout = ({ children }) => {
    return (
        <div className='grid grid-cols-1 lg:grid-cols-3 h-screen z-20'>
            {children}
        </div>
    )
}

export default PageLayout