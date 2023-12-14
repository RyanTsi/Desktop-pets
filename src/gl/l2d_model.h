#pragma once

#include <QObject>
#include <CubismFramework.hpp>
#include <Model/CubismUserModel.hpp>
#include <ICubismModelSetting.hpp>
#include <Type/csmRectF.hpp>
#include <Rendering/OpenGL/CubismOffscreenSurface_OpenGLES2.hpp>
#include <TextureManager.h>

class L2dModel : public QObject, public Csm::CubismUserModel {
    Q_OBJECT
public:
    explicit L2dModel();
    ~L2dModel();

public:
    // Initialize, model3.json从所在的路径生成模型
    void LoadAssets(const Csm::csmChar* dir, const  Csm::csmChar* fileName);
    // Paint
    // 重新构建连动器
    void ReloadRenderer();
    // 模型更新处理，通过模型的参数来决定绘画状态
    void Update();
    void Draw(Csm::CubismMatrix44& matrix);
    // Motion && Expression
    /**
     * @brief   开始再现由参数指示的运动。
     *
     * @param[in]   group                       运动团体名
     * @param[in]   no                          组内的号码
     * @param[in]   priority                    优先级
     * @param[in]   onFinishedMotionHandler     运动再现结束时调用的回调函数。如果为空，则不被调用。
     * @return                                  返回开始的运动的识别号码。作为判断单独运动是否结束的IsFinished()的自变量使用。不能开始时用“-1”
     */
    Csm::CubismMotionQueueEntryHandle StartMotion
        (const Csm::csmChar* group, Csm::csmInt32 no, Csm::csmInt32 priority,
            Csm::ACubismMotion::FinishedMotionCallback onFinishedMotionHandler = nullptr);

    /**
     * @brief   开始播放随机选出的运动。
     *
     * @param[in]   group                       运动团体名
     * @param[in]   priority                    优先级
     * @param[in]   onFinishedMotionHandler     运动再现结束时调用的回调函数。如果为空，则不被调用。
     * @return                                  返回开始的运动的识别号码。作为判断单独运动是否结束的IsFinished()的自变量使用。不能开始时用“-1”
     */
    Csm::CubismMotionQueueEntryHandle StartRandomMotion
        (const Csm::csmChar* group, Csm::csmInt32 priority,
            Csm::ACubismMotion::FinishedMotionCallback onFinishedMotionHandler = nullptr);

    /**
     * @brief   设置由参数指定的表情动作
     *
     * @param   expressionID    动作表情的id
     */
    void SetExpression(const Csm::csmChar* expressionID);

    /**
     * @brief   设置随机选择的表情和动作
     *
     */
    void SetRandomExpression();
    // Event && HitBox
    /**
    * @brief   接受事件的触发器
    */
    virtual void MotionEventFired
        (const Live2D::Cubism::Framework::csmString& eventValue);
    /**
     * @brief    中奖判定测试。
     *           根据指定ID的顶点列表计算矩形，判断坐标是否在矩形范围内。
     *
     * @param[in]   hitAreaName     测试判定的对象的ID
     * @param[in]   x               进行判定的X坐标
     * @param[in]   y               进行判定的Y坐标
     */
    virtual Csm::csmBool HitTest
        (const Csm::csmChar* hitAreaName, Csm::csmFloat32 x, Csm::csmFloat32 y);
private:
    Csm::csmString _modelHomeDir; // 有模型设置的目录
    Csm::ICubismModelSetting* _modelSetting; // 模型设定信息
    void SetupModel(Csm::ICubismModelSetting* setting);
    void SetupTextures();
    TexManager* _texManager;

    void PreloadMotionGroup(const Csm::csmChar* group);
    void ReleaseMotionGroup(const Csm::csmChar* group) const;
    void ReleaseMotions();
    void ReleaseExpressions();

    Csm::csmVector<Csm::CubismIdHandle> _eyeBlinkIds; // 在模型中设置的眨眼功能参数ID
    Csm::csmVector<Csm::CubismIdHandle> _lipSyncIds;  // 在模型中设定的对口型功能用参数ID
    Csm::csmMap<Csm::csmString, Csm::ACubismMotion*>   _motions; // 正在读取的运动列表
    Csm::csmMap<Csm::csmString, Csm::ACubismMotion*>   _expressions; // 正在读取的表情列表

private:
    Csm::csmVector<Csm::csmRectF> _hitArea;
    Csm::csmVector<Csm::csmRectF> _userArea;
    const Csm::CubismId* _idParamAngleX;     // 参数ID: ParamAngleX
    const Csm::CubismId* _idParamAngleY;     // 参数ID: ParamAngleX
    const Csm::CubismId* _idParamAngleZ;     // 参数ID: ParamAngleX
    const Csm::CubismId* _idParamBodyAngleX; // 参数ID: ParamBodyAngleX
    const Csm::CubismId* _idParamEyeBallX;   // 参数ID: ParamEyeBallX
    const Csm::CubismId* _idParamEyeBallY;   // 参数ID: ParamEyeBallXY
signals:
    /* Utils */
private:
    Csm::csmFloat32 _userTimeSeconds;
};