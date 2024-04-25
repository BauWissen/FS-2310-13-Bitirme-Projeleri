import React from 'react'
import LogoFull from '../../../../css/logo/logofull.png'
import { Link } from 'react-router-dom'

const LeftDescription = () => {
    return (
        <div className='bg-zinc-900 px-5 py-10 lg:p-20 relative  order-last lg:order-1'>
            <div className=' top-5 left-5 absolute hidden lg:flex'>
              <Link to="/">  <img src={LogoFull} width={100} /></Link>
            </div>
            <div className='w-full h-full flex flex-col justify-center items-center'>
                <div className='flex flex-col gap-14 justify-center items-center'>
                    <div className='text-2xl italic text-center'>
                        "<big className='text-orange-300'>Team Task</big>, ekibinizin verimliliğini artırmak için tasarlanmış kullanıcı dostu bir görev yönetim platformudur. Projenizi kolayca organize edin, görevleri atayın ve ilerlemeyi izleyin. Birlikte daha fazlasını başarın! <big className='text-orange-300'>#TeamTask</big>  💼✅"
                    </div>
                    <div className='text-slate-200'>
                        <Link target='_blank' to="https://www.ozcevahir.com">© Özcevahir 2024</Link>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default LeftDescription