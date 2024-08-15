import { createAsyncThunk } from "@reduxjs/toolkit"
//api
import CourseAPI from "../../../utils/APIs/CourseAPI"
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel"
import { CourseDetailViewModel } from "../../../models/viewModels/CourseDetailViewModel"

export const GetAllCourses = createAsyncThunk<CourseViewModel[]>(
    'Course/GetAllCourses',
    async () => {
        const response = await CourseAPI.GetAllCourses()
        return response.data
    }
)

export const GetCourseDetailById = createAsyncThunk<CourseDetailViewModel, number>(
    'Course/GetCourseDetailById',
    async (id: number) => {
        const response = await CourseAPI.GetCourseDetailById(id)
        return response.data
    }
)