import React, { useEffect } from 'react'
//redux
import { useSelector } from 'react-redux'
import { RootState, useAppDispatch } from '../../../redux/app/store'
import { GetAllCourses } from '../../../redux/features/course/thunks'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CoursesPage from './CoursesPage'

const CoursesPageLoader = () => {
    const dispatch = useAppDispatch()
    const { loading } = useSelector((state: RootState) => state.course)

    useEffect(() => {
        dispatch(GetAllCourses())
    }, [dispatch])

    if (loading) return <LoadingComponent />

    return (
        <CoursesPage />
    )
}

export default CoursesPageLoader