import axios from 'axios'
import React from 'react'

const IsUser = () => {
  return (
    <div className='w-full bg-red-500'>

<button onClick={()=>{

axios.get("http://localhost:5157/test/isuser",{withCredentials:true}).then((res)=>{
})


}}>click</button>



    </div>
  )
}

export default IsUser