import { useEffect } from 'react'
//redux
import { useSelector } from 'react-redux'
import { useAppDispatch } from '../../../redux/app/store'
import { GetAllCourses } from '../../../redux/features/course/thunks'
import { selectCoursesLoading } from '../../../redux/features/course/selectors'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CoursesPage from './CoursesPage'

const CoursesPageLoader = () => {
    const dispatch = useAppDispatch()
    const loading = useSelector(selectCoursesLoading)

    useEffect(() => {
        dispatch(GetAllCourses())
    }, [dispatch])

    if (loading) return <LoadingComponent />

    return (
        <CoursesPage />
    )
}

export default CoursesPageLoader