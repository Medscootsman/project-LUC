using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    class FixedUncertainties
    {

        protected const double mathematicalModelUncertainty = 0.04;

        protected const double meterElectronicsUncertainty = 0.001;

        protected const double flowProfileCorrFactorUncertainty = 0.3;

        protected const double operationalInfluenceUncertainty = 0.1;

        protected const double noiseInterferenceUncertainty = 0.01;

        protected const double distortionUncertainty = 0.01;

        protected const double computerCalculationUncertainty = 0.01;

        protected const double psuUncertainty = 0.01;

        protected const double flowCalibrationUncertainty = 0.2;

        protected const double transducerdistanceUncertainty = 0.001;

        public FixedUncertainties()
        {

        }

        public double MathModel
        {
            get => mathematicalModelUncertainty;
        }

        /// <summary>
        /// Gets the Flow Profile Correction Factor Uncertainty
        /// </summary>
        public double FlowProfileCorrectionFactor
        {
            get => flowProfileCorrFactorUncertainty;
        }

        public double OperationalInfluence
        {
            get => operationalInfluenceUncertainty;
        }

        public double NoiseInterfence
        {
            get => noiseInterferenceUncertainty;
        }

        public double Distortion
        {
            get => distortionUncertainty;
        }

        public double ComputerCalculation
        {
            get => computerCalculationUncertainty;
        }

        public double PowerSupplyVariation
        {
            get => psuUncertainty;
        }

        public double FlowCalibrationUncertainty
        {
            get => flowCalibrationUncertainty;
        }

        public double TransducerDistance
        {
            get => transducerdistanceUncertainty;
        }

        public double MeterElectronics
        {
            get => meterElectronicsUncertainty;
        }
    }
}
