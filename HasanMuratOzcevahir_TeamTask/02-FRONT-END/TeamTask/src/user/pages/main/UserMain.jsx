import React, { useEffect } from 'react'
import TopMenu from '../../components/globals/menu/TopMenu'
import { useDispatch, useSelector } from 'react-redux'
import { setCurrentUser } from '../../features/user/loginSlice'

const UserMain = () => {
    const dispatch = useDispatch()

    useEffect(() => {

        dispatch(setCurrentUser("home"))


    }, [])


    return (
        <>
            <TopMenu />
            <div className=' bg-orange-300 py-5'>

                <div className='flex flex-col mx-20 '>
                    <section className='text-center text-5xl text-slate-800 lg:p-20'>
                        <span> "TeamTask, ekip üyelerinin işbirliği içinde verimli bir şekilde çalışmalarını sağlayan kullanıcı dostu bir görev yönetim platformudur.  

                        </span>
                    </section>
                    <section>
                        <span>Çalışma alanlarının görünümü</span>
                        <img src="https://i.hizliresim.com/6m5zfip.jpg" className='object-contain rounded-xl' />

                    </section>


                </div>
                <div  className='text-center text-5xl text-slate-800 lg:p-20'>
                    <section>
                        Kolay kullanılabilir arayüzü ve göz alıcı tasarımı ile, ekiplerin projelerini kolayca planlamasına, görevleri atamasına, ilerlemeyi izlemesine ve birlikte çalışmasına olanak tanır.
                    </section>

                </div>
                <div  className='text-center text-5xl text-slate-800 lg:p-20'>
                    <section>
                    TeamTask, karmaşık projeleri yönetmeyi basitleştirir ve ekip üyelerinin odaklanmasını ve başarıya odaklanmasını sağlar."
                    </section>

                </div>
            </div>
            <footer>

            </footer>

        </>
    )

}
export default UserMain