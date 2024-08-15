import { useEffect } from 'react'
//redux
import { useSelector } from 'react-redux'
import { useAppDispatch } from '../../../redux/app/store'
import { GetCurrentStudentCourses } from '../../../redux/features/student/thunks'
import { selectCurrentStudentCoursesLoading } from '../../../redux/features/student/selectors'
//components
import MyCoursesPage from './MyCoursesPage'
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'

const MyCoursesPageLoader = () => {
    const dispatch = useAppDispatch()
    const loading = useSelector(selectCurrentStudentCoursesLoading)

    useEffect(() => {
        dispatch(GetCurrentStudentCourses())
    }, [dispatch])

    if(loading) return <LoadingComponent/>

    return (
        <MyCoursesPage />
    )
}

export default MyCoursesPageLoader