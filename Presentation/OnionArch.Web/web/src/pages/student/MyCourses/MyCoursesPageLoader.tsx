import { useEffect } from 'react'
//redux
import { useSelector } from 'react-redux'
import { useAppDispatch } from '../../../redux/app/store'
import { selectStudentAttendedCoursesLoading } from '../../../redux/features/currentStudent/selectors'
import { GetCoursesAttendedByCurrentStudent } from '../../../redux/features/currentStudent/thunks'
//components
import MyCoursesPage from './MyCoursesPage'
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'

const MyCoursesPageLoader = () => {
    const dispatch = useAppDispatch()
    const loading = useSelector(selectStudentAttendedCoursesLoading)

    useEffect(() => {
        dispatch(GetCoursesAttendedByCurrentStudent())
    }, [dispatch])

    if(loading) return <LoadingComponent/>

    return (
        <MyCoursesPage />
    )
}

export default MyCoursesPageLoader