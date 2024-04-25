import React from 'react'
import { LoadingSpinner } from '../../../../top-global-component/TopGlobalComponentExport'

const SubmitButton = ({ disabled, textValue }) => {
    return (

        <button disabled={disabled} type='submit' className='bg-orange-100 p-3 rounded-md hover:bg-orange-200 transition-all duration-300 disabled:pointer-events-none disabled:bg-orange-50'
        >
            {disabled ? <LoadingSpinner/> : textValue}
        </button>

    )
}

export default SubmitButton