import { BaseAPI } from "./BaseAPI";
//models
import { AxiosResponse } from "axios";

class CourseAPI extends BaseAPI {
    private controllerExtension: string = "/Course"

    constructor() {
        super();
    }

    public async GetAllCourses(): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetAllCourses')
    }

}

export default new CourseAPI()